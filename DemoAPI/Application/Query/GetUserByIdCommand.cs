using MediatR;
using System.Net.Http;
using static DemoAPI.Model.Response.GetAllUserReponseModel;

namespace DemoAPI.Application.Query
{
    public class GetUserByIdCommand : IRequest<User>
    {
        public long Id { get; set; }
    }

    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, User>
    {
        private readonly HttpClient _httpClient;

        public GetUserByIdCommandHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var mUser = await _httpClient.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users", cancellationToken);
            return mUser.FirstOrDefault(x => x.Id == request.Id);
        }
    }
}
