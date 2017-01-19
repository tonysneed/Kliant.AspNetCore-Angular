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

    // Checking directly for the existence of a method does not compile
    // function learnOrTeach(person: Person) {
    //     if (person.teach) {
    //         person.teach();
    //     }
    //     if (person.learn) {
    //         person.learn();
    //     }
    // }

    // Use the as operator to assert specific types
    function learnOrTeach(person: Person) {
        if ((person as Teacher).teach) {
            (person as Teacher).teach();
        }
        if ((person as Student).learn) {
            (person as Student).learn();
        }
    }

    let student = new Student();
    let teacher = new Teacher();
    learnOrTeach(student);
    learnOrTeach(teacher);
}