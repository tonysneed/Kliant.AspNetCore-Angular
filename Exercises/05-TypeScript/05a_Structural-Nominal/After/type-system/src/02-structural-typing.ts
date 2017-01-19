namespace structural_typing {

    class Person {
        name: string;
        age: number;
    }

    class Student {
        name: string;
        age: number;
        enrolled: Date;
    }

    // Structural typing with Person
    function birthday(person: Person) {
        person.age += 1;
    }

    let joe: Person = new Student();
    joe.age = 18;
    birthday(joe);
    console.log(joe.age);
}