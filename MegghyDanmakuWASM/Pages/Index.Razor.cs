using Blazored.LocalStorage;
using MegghyDanmakuShared.PageData;
using Microsoft.AspNetCore.Components;

namespace MegghyDanmakuWASM.Pages
{
    public partial class Index
    {
        [Inject]
        protected HttpClient? _httpClient { get; set; }
        [Inject]
        protected NavigationManager? _navigationManager { get; set; }
        [Inject]
        protected NotificationService? _notice { get; set; }
        [CascadingParameter]
        protected LocalData? _localData { get; set; }

        private static ChannelRankType _displayType = ChannelRankType.LastLive;
        private static ChannelInteractionType _interactionType = ChannelInteractionType.TenMin;
        private static PageData_Index _currentData = new();
        private static int _currentPage = 0;
        private static bool _isLoading = true;
        private static string _searchUidString;
        private static string _keyword;
        private static string _selectedArea;

        protected override async Task OnInitializedAsync()
        {
            await GetChannelInfo();
            _isLoading = false;
            await base.OnInitializedAsync();
        }
        /// <summary>
        /// 获取直播间数据
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task GetChannelInfo()
        {
            _isLoading = true;
            try
            {
                _currentPage = 0; //从第一页开始

                _currentData = await _httpClient?.GetEntityAsync<PageData_Index>(API.DATA_INDEX, HttpMethod.Get, new()
                {
                    { "type", _displayType },
                    { "interactionType", _interactionType },
                    { "keyword", _keyword },
                    { "area", _selectedArea },
                    { "pageNum", _currentPage },
                });
                _isLoading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task GetChannelInfoByIds(IEnumerable<long> ids)
        {
            _isLoading = true;
            try
            {
                _currentPage = 0; //从第一页开始

                _currentData = await _httpClient?.GetEntityAsync<PageData_Index>(API.DATA_INDEX_GET_BY_ID, HttpMethod.Post, new()
                {
                    { "ids", ids },
                });
                _isLoading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task SearchUser()
        {
            if (Utils.TryParseUid(_searchUidString, out var id))
            {
                _navigationManager.NavigateTo($"/{User.PAGE_ROUTE_USER}/{id}");
            }
            else
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "错误",
                    Description = "输入的不是有效的用户Id: " + _searchUidString,
                    NotificationType = NotificationType.Error
                });
            }
        }
        public async Task OnFavorite(APIChannelInfo channel)
        {
            bool isFavorite = true;
            if (_localData?.FavoriteChannels.Contains(channel.UId) == true)
            {
                _localData.FavoriteChannels.Remove(channel.UId);
            }
            else
            {
                _localData.FavoriteChannels.Add(channel.UId);
                isFavorite = false;
            }
            await localStorage.SetItemAsync(LocalData.LOCAL_NAME, _localData);
            StateHasChanged();
            await _notice.Success(new()
            {
                Message = $"已{(isFavorite ? "取消" : "")}收藏主播 {channel}"
            });
        }
        public async Task ClearHistory()
        {
            _localData.SearchHistory?.Clear();
            await localStorage.SetItemAsync(LocalData.LOCAL_NAME, _localData);
            StateHasChanged();
        }
        public async Task OnDeleteHistory(long id)
        {
            _localData.SearchHistory?.Remove(id);
            await localStorage.SetItemAsync(LocalData.LOCAL_NAME, _localData);
            StateHasChanged();
        }
    }
}
