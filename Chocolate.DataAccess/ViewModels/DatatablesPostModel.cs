using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChocolateProject.ViewModels
{
    //to model pou stelnei sto back to datatable
    public class DatatablesPostModel
    {
        //to json pou erxetai apo kapou kai exei mesa toy draw mapparei se auto to property
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        [JsonProperty("search")]
        public Search Search { get; set; }

        [JsonProperty("order")]
        public List<Order> Order { get; set; }
    }

    public class Column
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        [JsonProperty("orderable")]
        public bool Orderable { get; set; }

        [JsonProperty("search")]
        public Search Search { get; set; }
    }

    public class Search
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("regex")]
        public bool Regex { get; set; }
    }

    public class Order
    {
        [JsonProperty("column")]
        public int Column { get; set; }

        [JsonProperty("dir")]
        public string Dir { get; set; }
    }

    //to model pou stelnoyme emeis sto datatable
    public class DatatableResponse<T>
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public IEnumerable<T> data { get; set; }
    }
}
