using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserAPI.Models
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty(PropertyName= "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password  { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

    }
}
