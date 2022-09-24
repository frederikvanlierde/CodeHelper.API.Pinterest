using CodeHelper.Core.OAuth2;
using CodeHelper.Core.PlaceHolder;
using CodeHelper.Core.Extensions;
using System.Text.Json;
using System;
using System.Threading.Tasks;
namespace CodeHelper.API.Pinterest
{
    public sealed class PinterestHelper : OAuthProvider
    {
        #region Properties
        [Placeholder("{PRIVACY}")]  public string Privacy { get; set; } = PrivacyValues.All.Description();
        [Placeholder("{PAGESIZE}")] public int PageSize { get; set; } = 25;
        [Placeholder("{BOOKMARK}")] public string BookMark { get; set; } = "";
        [Placeholder("{BOARDID}")]  public string BoardID { get; set; } = "";
        [Placeholder("{SECTIONID}")] public string SectionID { get; set; } = "";
        [Placeholder("{ADACCOUNTID}")] public string AdAccountID { get; set; } = "";
        [Placeholder("{PINID}")] public string PinId { get; set; } = "";
        #endregion

        #region Constructors
        public PinterestHelper() { }
        #endregion

        #region Public Methods
        #region OAUTH Methods
        public override string GetOAuthTokenUrl()
        {
            this.ResponseType = "code";
            this.Endpoint = Constants.APIURL_OAUTH;
            this.State = Guid.NewGuid().ToString();
            return base.GetOAuthTokenUrl();
        }
        /// <summary>
        ///  Gets the Pinterest accesscode and store it in the field AccessToken
        /// </summary>
        public override async Task GetAccessToken()
        {
            this.GrantType = "authorization_code";            
            this.Endpoint = Constants.APIURL_GETTOKEN;
            await base.GetAccessToken();
        }
        #endregion

        #region User Account Methods
        /// <summary>
        /// Get account information for the "operation user_account"
        /// </summary>        
        public async Task<UserAccountInfo> UserGetAccountInfo()
        {            
            return await GetJson<UserAccountInfo>(Constants.APIURL_USERGETACCOUNTINFO);
        }
        #endregion
        #region Board API Methods
        /// <summary>
        /// Get a list of the boards owned by the "operation user_account" + group boards where this account is a collaborator
        /// </summary>
        /// <param name="privacy">string optional, "PUBLIC" "PROTECTED" "SECRET"</param>
        /// <param name="page_size">int optional, between 0 and 100, default 25</param>
        /// <param name="bookmark">string optional, Cursor used to fetch the next page of items</param>
        public async Task<BoardsResult> BoardsGetList(string privacy = "", int page_size=25, string bookmark="")
        {
            this.Privacy = privacy;
            this.PageSize = page_size;
            this.BookMark = bookmark;
            return await GetJson<BoardsResult>(Constants.APIURL_BOARDS.Replace(this));
        }

        /// <summary>
        /// Get a board owned by the operation user_account - or a group board that has been shared with this account.
        /// </summary>
        /// <param name="board_id">string, required: id of the baord</param>
        public async Task<Board> BoardGetInfo(string board_id)
        {
            this.BoardID = board_id;
            return await GetJson<Board>(Constants.APIURL_BOARDINFO.Replace(this));
        }

        /// <summary>
        /// Get a list of all board sections from a board owned by the "operation user_account" - or a group board that has been shared with this account.
        /// </summary>
        /// <param name="board_id">string, required: id of the baord</param>
        public async Task<BoardSection> BoardGetListSections(string board_id, int page_size=25, string bookmark="")
        {
            this.BoardID = board_id;
            this.PageSize = page_size;
            this.BookMark = bookmark;
            return await GetJson<BoardSection>(Constants.APIURL_BOARDLISTSECTIONS.Replace(this));
        }

        /// <summary>
        /// Get a list of the Pins on a board owned by the "operation user_account" - or on a group board that has been shared with this account.
        /// </summary>
        /// <param name="board_id">string, required: id of the board</param>
        /// <param name="page_size">int, optional: Maximum number of items to include in a single page of the response Between 0 and 100, default 25</param>
        /// <param name="bookmark">string, optional: Cursor used to fetch the next page of items</param>
        public async Task<PinResults> BoardListPins(string board_id, int page_size = 25, string bookmark = "")
        {
            this.BoardID = board_id;
            this.PageSize = page_size;
            this.BookMark = bookmark;
            return await GetJson<PinResults>(Constants.APIURL_BOARDLISTPINS.Replace(this));
        }

        /// <summary>
        /// Get a list of the Pins on a board section of a board owned by the "operation user_account" - or on a group board that has been shared with this account.
        /// </summary>
        /// <param name="board_id">string, required: id of the board</param>
        /// <param name="section_id">string, required: id of the section</param>
        /// <param name="page_size">int, optional: Maximum number of items to include in a single page of the response Between 0 and 100, default 25</param>
        /// <param name="bookmark">string, optional: Cursor used to fetch the next page of items</param>
        public async Task<PinResults> BoardSectionListPins(string board_id, string section_id, int page_size = 25, string bookmark = "")
        {
            this.BoardID = board_id;
            this.SectionID = section_id;
            this.PageSize = page_size;
            this.BookMark = bookmark;
            return await GetJson<PinResults>(Constants.APIURL_BOARDSECTIONLISTPINS.Replace(this));
        }

        /// <summary>
        /// Create a board owned by the "operation user_account".
        /// </summary>
        /// <param name="name">string, required</param>
        /// <param name="description">string, optional</param>
        /// <param name="privacy">string, required, default public ("PUBLIC" "PROTECTED" "SECRET")</param>
        /// <returns></returns>
        public async Task<Board> BoardCreate(string name, string description, string privacy = "PUBLIC")
        {
            Board _new = new() { Name = name, Description = description, Privacy = privacy };
            return await PostJson<Board>(Constants.APIURL_BOARDCREATE.Replace(this),_new.GetJsonString());
        }
        /// <summary>
        /// Create a board section on a board owned by the "operation user_account" - or on a group board that has been shared with this account.
        /// </summary>
        /// <param name="board_id">string, required: Unique identifier of a board.</param>
        /// <param name="name">	string[1..180] characters, required</param>        
        public async Task<BoardSection> BoardSectionCreate(string board_id, string name)
        {
            this.BoardID = board_id;
            BoardSection _new = new() { Name = name };
            return await PostJson<BoardSection>(Constants.APIURL_BOARDSECTIONCREATE.Replace(this), _new.GetJsonString());
        }
        /// <summary>
        /// Update a board owned by the "operating user_account".
        /// </summary>
        /// <param name="board_id">string, required: Unique identifier of a board.</param>        
        public async Task<Board> BoardUpdate(string board_id, string name, string description, string privacy = "PUBLIC")
        {
            this.BoardID = board_id;
            Board _new = new() { Name = name, Description = description, Privacy = privacy };
            return await PostJson<Board>(Constants.APIURL_BOARDUPDATE.Replace(this), _new.GetJsonString());
        }
        /// <summary>
        /// Update a board owned by the "operating user_account".
        /// </summary>
        /// <param name="board_id">string, required: Unique identifier of a board.</param>        
        public async Task<BoardSection> BoardSectionUpdate(string board_id, string section_id, string name, string description, string privacy = "PUBLIC")
        {
            this.BoardID = board_id;
            this.SectionID = section_id;
            Board _new = new() { Name = name, Description = description, Privacy = privacy };
            return await PostJson<BoardSection>(Constants.APIURL_BOARDSECTIONUPDATE.Replace(this), _new.GetJsonString());
        }
        /// <summary>
        /// Delete a board owned by the "operation user_account".
        /// </summary>
        /// <param name="board_id">string, required: Unique identifier of a board.</param>        
        public async Task BoardDelete(string board_id)
        {
            this.BoardID = board_id;
            await DeleteRequest(Constants.APIURL_BOARDDELETE.Replace(this));
        }
        /// <summary>
        /// Delete a board section on a board owned by the "operation user_account" - or on a group board that has been shared with this account.
        /// </summary>
        /// <param name="board_id">string, required: Unique identifier of a board.</param>        
        /// <param name="section_id">string. required: Unique identifier of a board section.</param>
        public async Task BoardSectionDelete(string board_id, string section_id)
        {
            this.BoardID = board_id;
            this.SectionID = section_id;
            await DeleteRequest(Constants.APIURL_BOARDDELETE.Replace(this));
        }
        #endregion

        #region Pin API Methods
        /// <summary>
        /// Create a Pin on a board or board section owned by the "operation user_account".
        /// </summary>        
        public async Task<object> CreatePin(string link, string title, string? boardId = null, string? description = null, string? mediaType = "image/jpeg", string? image_url = null, string? altText = null, string? board_section_id = null, string? parent_pin_id = null, string? dominant_color= null)
        {
            
            Pin  _pin = new() { Link = link, Title = title, Description = description, AltText = altText
                                , BoardID = boardId, BoardsectionID = board_section_id, ParentPinId = parent_pin_id
                                , DominantColor = dominant_color};

            if (!string.IsNullOrEmpty(image_url))
                _pin.Media = new() { ContentType = "", Url = image_url, SourceType = "image_url" };
            return await PostJson<object>(Constants.APIURL_CREATEPIN.Replace(this), _pin.GetJsonString());
        }

        /// <summary>
        /// Get a Pin owned by the "operation user_account" - or on a group board that has been shared with this account.
        /// </summary>
        /// <param name="pin_id">string, required: Unique identifier of a Pin.</param>
        public async Task<Pin> PinGetInfo(string pin_id, string ad_account_id=null)
        {
            this.PinId = pin_id;
            this.AdAccountID = ad_account_id;
            return await GetJson<Pin>(Constants.APIURL_PININFO.Replace(this));
        }
        /// <summary>
        /// Delete a Pins owned by the "operation user_account" - or on a group board that has been shared with this account.
        /// </summary>
        /// <param name="pin_id">string, required: Unique identifier of a Pin.</param>
        public async Task PinDelete(string pin_id)
        {
            this.PinId = pin_id;
            await DeleteRequest(Constants.APIURL_BOARDDELETE.Replace(this));
        }
        /// <summary>
        /// Save a pin on a board or board section owned by the "operation user_account".
        /// </summary>
        /// <param name="pin_id">string, required: Unique identifier of a Pin.</param>
        public async Task<Pin> PinSave(string pin_id, string board_id, string? board_section_id=null)
        {
            this.PinId = pin_id;
            Pin _new = new() { BoardID = board_id, BoardsectionID = board_section_id };
            return await PostJson<Pin>(Constants.APIURL_PINSAVE.Replace(this), _new.GetJsonString());
        }
        #endregion
        #endregion

    }
}