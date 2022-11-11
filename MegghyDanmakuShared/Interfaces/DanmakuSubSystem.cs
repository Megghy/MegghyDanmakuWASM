using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegghyDanmakuShared.Interfaces
{
    public interface IDanmakuServer
    {
        public void RecieveDanmakus(List<(long id, APIDanmakuInfo danmaku)> danmakus);

        public void OnLiveStop(long id, DateTime date);

        public void OnWatchChange(long id, int watchCount);
        public Task<TimeSpan> Ping(DateTime time);
    }
    public interface IDanmakuClient
    {
        public void Stop();
        public Task<List<long>> GetRecievingChannels();
        public Task<bool> ConnectChannel(long id);
        public void DisconnectChannel(long channelId);
        public void Disconnect();
    }
}
