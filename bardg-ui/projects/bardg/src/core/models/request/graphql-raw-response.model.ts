export class GraphQlRawResponse<T> {
  data: T;
  errors: GraphQlRawResponseError[];
}

export interface GraphQlRawResponseError {
  message: string;
}
