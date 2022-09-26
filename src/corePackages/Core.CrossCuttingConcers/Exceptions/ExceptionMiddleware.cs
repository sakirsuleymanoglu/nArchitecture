﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.CrossCuttingConcerns.Exceptions;


public static class HttpStatusCodeExtensions
{
    public static int ConvertToInt(this HttpStatusCode httpStatusCode) => (int)httpStatusCode;
}

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is ValidationException) return CreateValidationException(context, exception);
        if (exception is BusinessException) return CreateBusinessException(context, exception);
        if (exception is AuthorizationException)
            return CreateAuthorizationException(context, exception);
        return CreateInternalException(context, exception);
    }

    private Task CreateAuthorizationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = HttpStatusCode.Unauthorized.ConvertToInt();

        return context.Response.WriteAsync(new AuthorizationProblemDetails
        {
            Status = context.Response.StatusCode,
            Type = "https://example.com/probs/authorization",
            Title = "Authorization exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateBusinessException(HttpContext context, Exception exception)
    {
        if (exception is BusinessException businessException)
            context.Response.StatusCode = businessException.BusinessExceptionType == BusinessExceptionTypes.NotFound ? HttpStatusCode.NotFound.ConvertToInt() : HttpStatusCode.BadRequest.ConvertToInt();
        else
            context.Response.StatusCode = HttpStatusCode.BadRequest.ConvertToInt();

        return context.Response.WriteAsync(new BusinessProblemDetails
        {
            Status = context.Response.StatusCode,
            Type = "https://example.com/probs/business",
            Title = "Business exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateValidationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = HttpStatusCode.BadRequest.ConvertToInt();
        object errors = ((ValidationException)exception).Errors;

        return context.Response.WriteAsync(new ValidationProblemDetails
        {
            Status = context.Response.StatusCode,
            Type = "https://example.com/probs/validation",
            Title = "Validation error(s)",
            Detail = "",
            Instance = "",
            Errors = errors
        }.ToString());
    }

    private Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = HttpStatusCode.InternalServerError.ConvertToInt();

        return context.Response.WriteAsync(new ProblemDetails
        {
            Status = context.Response.StatusCode,
            Type = "https://example.com/probs/internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }
}