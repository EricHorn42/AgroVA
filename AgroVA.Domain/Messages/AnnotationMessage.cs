﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages;

public static class AnnotationMessage
{
    public const string InvalidId = "Id inválido";
    public const string InvalidObservation = "Observação inválida";
    public const string InvalidTimestamp = "Data inválida";
    public const string LongObservation = "Observação muito longa";
    public const string RequiredObservation = "Observação é obrigatória";
    public const string RequiredTimestamp = "Data é obrigatória";
}
