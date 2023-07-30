import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.css']
})
export class TiendaComponent implements OnInit {

  constructor() {
    
  }
  Subtotal: number = 0;
  GastosEnvios: number = 0;
  Impuestos: number = 0;
  Total: number = 0;

  ngOnInit(): void {
    this.sumar();
  }

  productos = [
    {
      IdT: 1, item_name: 'Item 1', short_description: 'Descripcion 1', quantity: 1, price_without_tax: 19.32, tax: 16
      , shipping_fee: 20, precioBase:19.32
    },
    {
      IdT: 2, item_name: 'Item 2', short_description: 'Descripcion 2', quantity: 1, price_without_tax: 10.18, tax: 16
      , shipping_fee: 20, precioBase:10.18
    },
    {
      IdT: 3 ,item_name: 'Item 3', short_description: 'Descripcion 3', quantity: 1, price_without_tax: 59.11, tax: 16
      , shipping_fee: 20, precioBase: 59.11
    },
    {
      IdT: 4, item_name: 'Item 3', short_description: 'Descripcion 3', quantity: 1, price_without_tax: 45.60, tax: 16
      , shipping_fee: 20, precioBase: 45.60
    }
  ];

  aumentar(prod: any) {
    if (prod.quantity == undefined) {
      prod.quantity = 1;
      prod.price_without_tax = prod.precioBase * prod.quantity;

    } else if (prod.quantity != undefined) {
      ++prod.quantity;
      prod.price_without_tax = prod.precioBase * prod.quantity;
    }
    this.sumar();
  }

  disminuir(prod: any) {
    if (prod.quantity == undefined) {
      prod.quantity = 1;
      prod.price_without_tax = prod.precioBase * prod.quantity;
    }
    else {
      if (prod.quantity > 1) {
        prod.quantity--;
        prod.price_without_tax = prod.precioBase * prod.quantity;
      }
    }
    this.sumar();
  }

  borrarReg(prod: any) {
    this.productos.splice(prod.IdT - 1, 1);
    this.sumar();
  }

  sumar() {
    this.Subtotal = this.productos.reduce((acc, obj) => acc + (obj.price_without_tax), 0);
    this.GastosEnvios = this.productos.reduce((acc, obj) => acc + (obj.shipping_fee), 0);
    this.Impuestos = this.productos.reduce((acc, obj) => acc + (obj.price_without_tax * obj.tax / 100), 0);
    this.Total = this.Subtotal + this.GastosEnvios + this.Impuestos;
  }

  BorrarTodo() {
    this.productos = [];
    this.sumar();
  }

}




