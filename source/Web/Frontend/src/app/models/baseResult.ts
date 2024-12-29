export class BaseResult<T>{
    hasMessage? : boolean;
    hasValue? : boolean;
    message?: string;
    status? :number;
    value?: T;
}
