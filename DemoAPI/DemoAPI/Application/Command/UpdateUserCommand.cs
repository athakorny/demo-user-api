using MediatR;
using static DemoAPI.Model.Response.GetAllUserReponseModel;

namespace DemoAPI.Application.Command
{
    public class UpdateUserCommand : User, IRequest<User>
    {
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly HttpClient _httpClient;

        public UpdateUserCommandHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var url = $"https://jsonplaceholder.typicode.com/users/{request.Id}";

            var response = await _httpClient.PutAsJsonAsync(url, request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var updatedUser = await response.Content.ReadFromJsonAsync<User>(cancellationToken: cancellationToken);
            return updatedUser;
        }
    }
}
