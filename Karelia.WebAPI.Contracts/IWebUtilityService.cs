using System.Text;

namespace Karelia.WebAPI.Contracts
{
    public interface IWebUtilityService
    {
        /// <summary>Encodes a URL string.</summary>
        /// <param name="str">The text to encode. </param>
        /// <returns>An encoded string.</returns>
        string UrlEncode(string str);
        /// <summary>Do not use; intended only for browser compatibility. Use <see cref="M:System.Web.HttpUtility.UrlEncode(System.String)" />.</summary>
        /// <param name="str">The text to encode. </param>
        /// <returns>The encoded text.</returns>
        string UrlPathEncode(string str);
        /// <summary>Encodes a URL string using the specified encoding object.</summary>
        /// <param name="str">The text to encode. </param>
        /// <param name="e">The <see cref="T:System.Text.Encoding" /> object that specifies the encoding scheme. </param>
        /// <returns>An encoded string.</returns>
        string UrlEncode(string str, Encoding e);

        /// <summary>Converts a string that has been encoded for transmission in a URL into a decoded string.</summary>
        /// <param name="str">The string to decode. </param>
        /// <returns>A decoded string.</returns>
        string UrlDecode(string str);
        /// <summary>Converts a URL-encoded string into a decoded string, using the specified encoding object.</summary>
        /// <param name="str">The string to decode. </param>
        /// <param name="e">The <see cref="T:System.Text.Encoding" /> that specifies the decoding scheme. </param>
        /// <returns>A decoded string.</returns>
        string UrlDecode(string str, Encoding e);
    }
}