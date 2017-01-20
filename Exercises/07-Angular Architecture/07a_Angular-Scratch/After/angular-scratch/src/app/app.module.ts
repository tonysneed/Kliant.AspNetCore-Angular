import { NgModule } from "@angular/core";
import { BrowserModule  } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";

import { AppComponent } from "./app.component";

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
    ],
    declarations: [
        AppComponent
    ],
    providers: [/* TODO: Providers go here */],
    bootstrap: [AppComponent],
})
export class AppModule { }
