using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHelper.API.Pinterest
{
    internal static class Constants
    {
        internal static string APIURL_OAUTH = "https://www.pinterest.com/oauth/?client_id={CLIENTID}&redirect_uri={REDIRECTURL}&response_type={RESPONSETYPE}&scope={SCOPE}&state={STATE}";
        internal static string APIURL_GETTOKEN = "https://api.pinterest.com/v5/oauth/token";
        internal static string APIURL_CREATEPIN = "https://api.pinterest.com/v5/pins";
        internal static string APIURL_BOARDS = "https://api.pinterest.com/v5/boards?page_size={PAGESIZE}&privacy={PRIVACY}&bookmark={BOOKMARK}";
        internal static string APIURL_BOARDINFO = "https://api.pinterest.com/v5/boards/{BOARDID}";
        internal static string APIURL_BOARDLISTSECTIONS = "https://api.pinterest.com/v5/boards/{BOARDID}/sections?page_size={PAGESIZE}&bookmark={BOOKMARK}";
        internal static string APIURL_BOARDLISTPINS = "https://api.pinterest.com/v5/boards/{BOARDID}/pins?page_size={PAGESIZE}&bookmark={BOOKMARK}";
        internal static string APIURL_BOARDSECTIONLISTPINS = "https://api.pinterest.com/v5/boards/{BOARDID}/sections/{SECTIONID}/pins?page_size={PAGESIZE}&bookmark={BOOKMARK}";
        internal static string APIURL_BOARDCREATE = "https://api.pinterest.com/v5/boards";
        internal static string APIURL_BOARDUPDATE = "https://api.pinterest.com/v5/boards?board_id={BOARDID}";
        internal static string APIURL_BOARDDELETE = "https://api.pinterest.com/v5/boards/{BOARDID}";
        internal static string APIURL_BOARDSECTIONCREATE = "https://api.pinterest.com/v5/boards/{BOARDID}/sections";
        internal static string APIURL_BOARDSECTIONUPDATE = "https://api.pinterest.com/v5/boards/{board_id}/sections/{section_id}";
        internal static string APIURL_PININFO = "https://api.pinterest.com/v5/pins/{PINID}";
        internal static string APIURL_PINDELETE = "https://api.pinterest.com/v5/pins/{PINID}";
        internal static string APIURL_PINSAVE = "https://api.pinterest.com/v5/pins/{PINID}/save";
        internal static string APIURL_USERGETACCOUNTINFO = "https://api.pinterest.com/v5/user_account";


    }
}
