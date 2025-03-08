using Microsoft.AspNetCore.SignalR;

namespace BuiTienQuat_SE1814_NET_PT2.Hubs
{
    public class SignalRServer : Hub
    {
        public async Task SendCustomerUpdate()
        {
            await Clients.All.SendAsync("RefreshStudentList");
        }
    }
}
