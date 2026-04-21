export class GlobalResponse {

    Data: any;
    Error: boolean = false;    

}
export interface GenericResponse<T> {
    Error: boolean;
    ErrorMessage: string;
    data: T;
}