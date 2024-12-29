import {AppComponent} from "src/app/components/component";

export abstract class AppInputComponent extends AppComponent<any> {
    type!: string;

    constructor (type: string) {
        super();
        this.type = type;
    }

    input ($event: any): void {
        this.value = $event.target.value;
    }
}


export abstract class AppInputCheckBoxComponent extends AppComponent<boolean> {
    type!: string;

    constructor (type: string) {
        super();
        this.type = type;
    }

    input ($event: any): void {

        if ($event.target.value.toLowerCase() === 'true')
            this.value = true;
        if ($event.target.value.toLowerCase() === 'false')
            this.value = false;

    }
}


export abstract class AppDateInputComponent extends AppComponent<any> {
    type!: string;

    constructor (type: string) {
        super();
        this.type = type;
    }

    input ($event: any): void {
        this.value = $event.target.value;
    }
}

export abstract class AppInputTextAreaComponent extends AppComponent<any> {
    type!: string;

    constructor (type: string) {
        super();
        this.type = type;
    }

    input ($event: any): void {
        this.value = $event.target.value;
    }
}
