namespace dynamic_typing {

    class Person {
        name: string;
        age: number;
    }

    class Student {
        enrolled: Date;
    }

    // Dynamic typing with any
    function birthday(person: any) {
        person.age += 1;
    }

    let joe: any = new Student();
    joe.age = 18;
    birthday(joe);
    console.log(joe.age);
}