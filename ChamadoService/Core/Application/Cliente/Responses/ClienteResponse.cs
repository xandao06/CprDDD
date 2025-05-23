using Application.Cliente.Dto;


namespace Application.Cliente.Responses
{
    public class ClienteResponse : Response
    {
        public ClienteDto ClienteData { get; set; }
    }
}
