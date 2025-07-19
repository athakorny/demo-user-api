using DemoAPI.Model;
using DemoAPI.Model.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static DemoAPI.Model.Response.GetAllUserReponseModel;

namespace DemoAPI.Application.Query
{
    public class GetAllUserCommand : IRequest<ResponseModel<List<User>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllUserCommandHandler : IRequestHandler<GetAllUserCommand, ResponseModel<List<User>>>
    {
        private readonly HttpClient _httpClient;

        public GetAllUserCommandHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseModel<List<User>>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            var result = new ResponseModel<List<User>>();
            var mUser = await _httpClient.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users", cancellationToken);

            result.TotalRecords = mUser.Count();

            #region Paging 
            if (request.PageSize == 0)
                request.PageSize = 10;
            if (request.PageIndex == 0)
                request.PageIndex = 1;
            request.PageIndex = request.PageIndex - 1;
            var paging = mUser.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            #endregion


            result.Data = paging.ToList();

            return result;
        }
    }
}
