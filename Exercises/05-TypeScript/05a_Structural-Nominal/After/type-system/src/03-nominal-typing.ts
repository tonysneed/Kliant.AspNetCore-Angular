namespace nominal_typing {

    class Person {
        protected gender: string;
        name: string;
        age: number;
    }

    class Student extends Person {
        enrolled: Date;
    }

    // Nominal typing with Person
    function birthday(person: Person) {
        person.age += 1;
    }

    let joe = new Student();
    joe.name = "Joe";
    joe.enrolled = new Date();
    joe.age = 18;
    birthday(joe);
    console.log(`Student named ${joe.name}, age ${joe.age}, enrolled on: ${joe.enrolled.toDateString()}`);
}