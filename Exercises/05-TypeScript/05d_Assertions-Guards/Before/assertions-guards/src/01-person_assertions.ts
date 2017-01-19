namespace person_assertions {

    class Person {
        name: string;
        age: number;
    }

    class Student extends Person {
        learn() {
            console.log("Learning ...");
        }
    }

    class Teacher extends Person {
        teach() {
            console.log("Teaching ...");
        }
    }
}