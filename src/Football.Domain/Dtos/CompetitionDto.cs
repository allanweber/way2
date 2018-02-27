using Football.Domain.Core.Dtos;

namespace Football.Domain.Dtos
{
    public class CompetitionDto: IDto
    {
        public int Id { get; set; }
        public string Caption { get; set; }
    }
}
