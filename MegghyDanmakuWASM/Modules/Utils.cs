using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using MegghyDanmakuShared.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MegghyDanmakuWASM.Modules
{
    public static class Utils
    {
        public static async Task NavigateToNewTab(this IJSRuntime js, string path)
        {
            await js.InvokeVoidAsync("open", path, "_blank");
        }

        #region 
        public static readonly JsonSerializerOptions jsonOption = new()
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        };
        public static async Task<T?> GetEntityAsync<T>(this HttpClient client, string url, HttpMethod method = null, Dictionary<string, object>? @params = null, Dictionary<string, object>? headers = null) where T : IMDMKSData
        {
            method ??= HttpMethod.Get;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var request = new HttpRequestMessage(method, new Uri(url));
            var respone = await client.RequestAsync(
                request, 
                @params?.ToDictionary(kv => kv.Key, kv => kv.Value?.ToString()), 
                headers?.ToDictionary(kv => kv.Key, kv => kv.Value?.ToString()));
            if (respone?.IsSuccessStatusCode == true)
            {
                try
                {
                    return JsonSerializer.Deserialize<T>((await respone!.Content!.ReadAsStringAsync()) ?? string.Empty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine($"[REQUEST FAIL] <{respone?.StatusCode}> {url}");
            }
            return default;
        }
        public static async Task<HttpResponseMessage?> RequestAsync(this HttpClient client, HttpRequestMessage request, Dictionary<string, string>? @params = null, Dictionary<string, string>? headers = null)
        {
            try
            {
                if (@params != null)
                    request.Content = new FormUrlEncodedContent(@params);
                if (headers != null)
                {
                    foreach (var kv in headers)
                    {
                        request.Headers.Add(kv.Key, kv.Value);
                    }
                }
                return await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.InnerException ?? ex).Message);
                return null;
            }
        }
        #endregion

        public static bool TryParseUid(string idString, out long uid)
        {
            if (string.IsNullOrEmpty(idString))
            {
                uid = -1;
                return false;
            }
            idString = idString.ToLower().Trim();
            if (idString.StartsWith("uid:") || idString.StartsWith("uid："))
            {
                idString = idString.Replace("uid:", "").Replace("uid：", "");
            }
            if (long.TryParse(idString, out uid) && uid > 0)
                return true;
            else
            {
                uid = -1;
                return false;
            }
        }

        public static List<CascaderNode> GetCascaderNodeFromEntity(IEnumerable<SimpleCascaderNode> node)
            => node?.Select(n => new CascaderNode()
            {
                Label = n.Label,
                Value = n.Value,
                Children = GetCascaderNodeFromEntity(n.Children)
            }).ToList() ?? new();
    }
}
