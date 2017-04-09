using System;
using System.Collections.Generic;

namespace LinkMyTravel.WebAPI.ViewModel
{
    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public TModel Model { get; set; }

        public IEnumerable<TModel> List { get; set; }
    }

    public interface ISingleModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }

        IEnumerable<TModel> List { get; set; }
    }

    public interface IResponse
    {
        String Message { get; set; }

        Boolean DidError { get; set; }

        String ErrorMessage { get; set; }
    }

    public interface IListModelResponse<TModel> : IResponse
    {
        Int32 PageSize { get; set; }

        Int32 PageNumber { get; set; }

        IEnumerable<TModel> Model { get; set; }
    }


}
