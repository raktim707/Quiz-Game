using Microsoft.AspNetCore.SignalR;

public class QuizHub : Hub 
{
    protected IHubContext<QuizHub> _context;
    public ILogger Logger { get; set; }

    public QuizHub(IHubContext<QuizHub> context)
    {
        _context = context;
    }
    public async Task SendMessage(string message)
    {
        
        await _context.Clients.All.SendAsync("ReceiveMessage", message);
    }
}
