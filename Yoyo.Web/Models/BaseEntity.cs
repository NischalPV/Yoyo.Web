using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yoyo.Web.Models
{
    /// <summary>
    /// The most basic entity that is required for the implementing models. All models can be inherited from this entity.
    /// </summary>
    /// <typeparam name="T">Datatype of property Id.</typeparam>
    public class BaseEntity<T>
    {
        public T Id { get; set; }

    }
}
