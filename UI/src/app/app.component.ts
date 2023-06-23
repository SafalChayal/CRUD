import { Component, OnInit } from '@angular/core';
import { CardserviceService } from './Service/cardservice.service';
import { Card } from './Models/card.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'CardsUIAng';
  card:Card[]=[];
  cards :Card={
    id:'',
    cardholderName:'',
    cardholderNumber:'',
    expiryMonth:'',
    expiryYear:'',
    cVV:''
  };
  constructor(private cardservice:CardserviceService){

  }
  ngOnInit(): void {
    this.getAllCards();
  }
  getAllCards(){
    this.cardservice.getAllCards()
    .subscribe(
      response =>{
        this.card=response;
        console.log(response);
      }
    );
  }

  //
  onSubmit(){

    if(this.cards.id ===''){
      this.cardservice.addCards(this.cards)
    .subscribe(
      response =>{
        //console.log(response);
        this.getAllCards();
        this.cards={
          id:'',
          cardholderName:'',
          cardholderNumber:'',
          expiryMonth:'',
          expiryYear:'',
          cVV:''
        }
      }

      
    );
    }
    else{
      this.UpdateCard(this.cards)
    }
    
  }
  PopulateCard(card: Card) {

      this.cards=card;
  }

  deletecard(id:string){
    this.cardservice.deletemethod(id)
    .subscribe(
      response =>{
        this.getAllCards();
      }
    )


  }

  UpdateCard(crmd:Card){
    this.cardservice.UpdateCard(crmd)
    .subscribe(
      response =>{
          this.getAllCards();
      }
    )
  }
}
