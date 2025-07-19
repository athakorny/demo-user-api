using MediatR;
using static DemoAPI.Model.Response.GetAllUserReponseModel;

namespace DemoAPI.Application.Command
{
    public class CreateUserCommand : User, IRequest<User>
    {
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly HttpClient _httpClient;

        public CreateUserCommandHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("https://jsonplaceholder.typicode.com/users", request, cancellationToken);

            response.EnsureSuccessStatusCode(); // throw ถ้าไม่ใช่ 2xx

            var createdUser = await response.Content.ReadFromJsonAsync<User>(cancellationToken: cancellationToken);
            return createdUser!;
        }
    }
}
