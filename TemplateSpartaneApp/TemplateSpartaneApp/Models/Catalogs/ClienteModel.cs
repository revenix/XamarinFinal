using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateSpartaneApp.Models.Catalogs
{
  public partial class ClienteListModel
  {
    [JsonProperty("Clientes")]
    public List<ClienteModel> Clients { get; set; }

    [JsonProperty("RowCount")]
    public long RowCount { get; set; }
  }

  public class ClienteModel {
    [JsonProperty("Folio")]
    public long Folio { get; set; }

    [JsonProperty("Fecha_de_Registro")]
    public DateTimeOffset ? FechaDeRegistro { get; set; }

    [JsonProperty("Hora_de_Registro")]
    public DateTimeOffset HoraDeRegistro { get; set; }

    [JsonProperty("Usuario_que_Registra")]
    public long UsuarioQueRegistra { get; set; }

    [JsonProperty("Nombre_Completo")]
    public string NombreCompleto { get; set; }

    [JsonProperty("Nombre")]
    public string Nombre { get; set; }

    [JsonProperty("Apellido_Paterno")]
    public string ApellidoPaterno { get; set; }

    [JsonProperty("Apellido_Materno")]
    public string ApellidoMaterno { get; set; }

    [JsonProperty("Fecha_de_Nacimiento")]
    public DateTimeOffset ? FechaDeNacimiento { get; set; }

    [JsonProperty("Correo_Electronico")]
    public string CorreoElectronico { get; set; }

    [JsonProperty("Celular")]
    public string  Celular { get; set; }

    [JsonProperty("Foto")]
    public long ? Foto { get; set; }

    [JsonProperty("Contrasena")]
    public string Contrasena { get; set; }

    [JsonProperty("Confirmar_Contrasena")]
    public string ConfirmarContrasena { get; set; }

    [JsonProperty("Estatus")]
    public long? Estatus { get; set; }

    [JsonProperty("Spartan_User")]
    public long? SpartanUser { get; set; }
     
    [JsonProperty("Foto_Spartane_File")]
    public long? FotoSpartaneFile { get; set; }
     
    [JsonProperty("Id")]
    public long Id { get; set; }


  }
}
