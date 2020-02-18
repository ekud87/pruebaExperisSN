import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import {environment} from '../../environments/environment'


@Injectable({
  providedIn: 'root'
})
export class InterviewService {

  constructor(private http: Http) { }

  index(): Promise<any> {
    return this.http
      .get(`${environment.api}/interview/getScheduleInterviewList`)
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }


  save(data): Promise<any> {
    return this.http
      .post(`${environment.api}/interview/setScheduleInterview`,data)
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  private extractData(res: Response) {
    let body = res.json()
    return body || {};
  }

  private handleError(error: any): Promise<any> {
    return Promise.reject(error.message || error);
  }

}
