import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';

export abstract class BaseService<T> {
    constructor(protected _http: HttpClient, protected actionUrl: string) {
    }

    getAll(): Observable<T[]> {
        return this._http.get<T[]>(this.actionUrl);
    }
    create(model: T): Observable<T> {
        return this._http.post<T>(`${this.actionUrl}`, model);
    }
    delete(id: number): Observable<T> {
        return this._http.delete<T>(`${this.actionUrl}${id}`);
    }
} 