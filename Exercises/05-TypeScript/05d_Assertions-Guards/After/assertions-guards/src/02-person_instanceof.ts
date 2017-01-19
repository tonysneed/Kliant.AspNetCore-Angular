namespace person_instanceof {

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

    // Use the as operator to assert specific types
    // function learnOrTeach(person: Person) {
    //     if ((person as Teacher).teach) {
    //         (person as Teacher).teach();
    //     }
    //     if ((person as Student).learn) {
    //         (person as Student).learn();
    //     }
    // }

    // Use the instanceof operator to check compatibility
    function learnOrTeach(person: Person) {
        if (person instanceof Teacher) {
            person.teach();
        }
        if (person instanceof Student) {
            person.learn();
        }
    }

    let student = new Student();
    let teacher = new Teacher();
    learnOrTeach(student);
    learnOrTeach(teacher);
}