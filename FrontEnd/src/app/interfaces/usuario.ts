export interface Usuario{
    id?: number,
    nombre: string,
    apellido: string,
    correoElectronico: string,
    fechaNacimiento: Date,
    telefono?: string,
    paisResidencia: string,
    informacionContacto: boolean
}