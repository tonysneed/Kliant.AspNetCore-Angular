import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Product } from '../models/product';
import { Urls } from '../constants';

@Injectable()
export class ProductsService {

  private _productsUrl = Urls.BaseUrl + 'api/product';

  constructor(private _http: Http) { }

  // Replaced with version using HTTP
  // getProducts(): Product[] {
  //   return [
  //     new Product(1, 'Product 1', 10),
  //     new Product(2, 'Product 2', 20),
  //   ];
  // }

  // Replaced with version using async / await
  // getProducts(): Promise<Product[]> {
  //   return this._http.get(this._productsUrl)
  //     .toPromise()
  //     .then(resp => resp.json() as Product[])
  //     .catch(this.handleError);
  // }

  // private handleError(error: any): Promise<any> {
  //   console.error('An error occurred', error);
  //   return Promise.reject(error.message || error);
  // }

  async getProducts(): Promise<Product[]> {
    try {
      return (await this._http.get(this._productsUrl)
        .toPromise()).json() as Product[];
    } catch (error) {
      throw error.message || error;
    }
  }
}
