export class BaseResult<T> {
    IsSucess: boolean;
    returnCode: string;
    returnMessage: string;
    Data: T;
}