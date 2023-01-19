using System.ComponentModel.DataAnnotations;

namespace CarSpairParts.Model
{
    public class SpairPartsModel
    {
        public int Id { get; set; }
        public string name { get; set; } = default!;
        //[DataType(DataType.Date)]
        public string engin { get; set; } = default!;
        public string mirror { get; set; } = default!;
        public decimal cost { get; set; } = default!;

        public string color { get; set; } = default!;

    }
}
