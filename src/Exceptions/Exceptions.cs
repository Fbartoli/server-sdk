﻿using Morph.Server.Sdk.Dto;
using Morph.Server.Sdk.Dto.Errors;
using Morph.Server.Sdk.Model.Errors;
using System;
using System.Collections.Generic;

namespace Morph.Server.Sdk.Exceptions
{

    public abstract class MorphClientBaseException : Exception
    {

        public MorphClientBaseException(string message) : base(message)
        {

        }
    }
    public class ResponseParseException : MorphClientBaseException
    {
        public string ServerResponseString { get; private set; }

        public ResponseParseException(string message, string serverResponse) : base(message)
        {
            ServerResponseString = serverResponse;
        }
        public ResponseParseException(string message) : base(message)
        {

        }
    }





    public class MorphClientGeneralException : MorphClientBaseException
    {
        public string Code { get; protected set; }
        public MorphClientGeneralException(string code, string message) : base(message)
        {
            Code = code;
        }
    }

    public class MorphApiConflictException : MorphClientGeneralException
    {

        public MorphApiConflictException(string message) : base(ReadableErrorTopCode.Conflict, message)
        {

        }
    }

    public class MorphApiNotFoundException : MorphClientGeneralException
    {

        public MorphApiNotFoundException(string message) : base(ReadableErrorTopCode.NotFound, message)
        {

        }
    }

    public class MorphApiUnauthorizedException : MorphClientGeneralException
    {

        public MorphApiUnauthorizedException(string message) : base(ReadableErrorTopCode.Unauthorized, message)
        {

        }
    }

    public class MorphApiForbiddenException : MorphClientGeneralException
    {

        public MorphApiForbiddenException(string message) : base(ReadableErrorTopCode.Forbidden, message)
        {

        }
    }

    public abstract class MorphApiCommandFailedException : MorphClientGeneralException
    {
        protected object _details { get; }
        public object Details { get { return _details; } }
        public string DetailsCode { get; private set; }

        public MorphApiCommandFailedException(object details, string message) : base(ReadableErrorTopCode.CommandFailed, message)
        {
            _details = details;
        }
    }

    public class MorphApiCommandFailedException<T> : MorphApiCommandFailedException
    {
        public new T Details { get { return (T)base._details; } }
        public MorphApiCommandFailedException(T details, string message) : base(details, message)
        {

        }
    }

    public class MorphApiBadArgumentException : MorphClientGeneralException
    {
        public List<FieldError> Details { get; private set; }
        public MorphApiBadArgumentException(List<FieldError> details, string message) : base(ReadableErrorTopCode.BadArgument, message)
        {
            Details = details;
        }
    }


}
