using MediatR;
using System.Net.Http;
using static DemoAPI.Model.Response.GetAllUserReponseModel;

namespace DemoAPI.Application.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public long Id { get; set; }    
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly HttpClient _httpClient;
        public DeleteUserCommandHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var mUser = await _httpClient.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users", cancellationToken);
            var exists = mUser.FirstOrDefault(x => x.Id == request.Id);

            if (exists == null)
                return false;

            var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/users/{request.Id}", cancellationToken);

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
