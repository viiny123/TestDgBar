import { ResponseError } from './response-error.model';

export class Response<T> {
    data: T;
    errors: ResponseError[];
}
