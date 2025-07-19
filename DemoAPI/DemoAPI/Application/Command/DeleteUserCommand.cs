using MediatR;
using System.Net.Http;

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
            var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/users/{request.Id}", cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return false;

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
