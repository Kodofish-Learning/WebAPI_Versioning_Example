using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using SDammann.WebApi.Versioning;

namespace Exercise.SDammann.WebApi.Versioning
{
    public class AcceptHeaderVersionedControllerSelector : AcceptHeaderVersionedControllerSelectorBase
    {
        /// <summary>
        /// Specifies the media type to accept. Set this in your Application_Start or before.
        /// </summary>
        public static string AcceptMediaType = "application/json";

        public AcceptHeaderVersionedControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Derived classes implement this to return an API version from the specified mime type string
        /// 由 MimeType 來判斷所使用的 版本號碼
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        protected override String GetVersion(MediaTypeWithQualityHeaderValue mimeType)
        {
            if (!String.Equals(mimeType.MediaType, AcceptMediaType, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            // get version
            NameValueHeaderValue versionParameter =
                mimeType.Parameters.FirstOrDefault(parameter => parameter.Name == "v");

            if (versionParameter == null || String.IsNullOrWhiteSpace(versionParameter.Value))
            {
                return null;
            }

            return versionParameter.Value;
        }
    }
}