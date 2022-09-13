using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Common.Enum
{
    public enum EnumTipoOcorrencia:int
    {
        [Description("Em rota de entrega")]
        EM_ROTA_DE_ENTREGA = 1,

        [Description("Entregue com sucesso, ")]
        ENTEGRA_SUCESSO = 2,

        [Description("Cliente ausente")]
        CLIENTE_AUSENTE = 3,

        [Description("Avaria no produto")]
        AVARIA = 4,
    }
}
