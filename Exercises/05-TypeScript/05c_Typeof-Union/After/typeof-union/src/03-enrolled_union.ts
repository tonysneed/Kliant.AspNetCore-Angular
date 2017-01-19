namespace enrolled_union {

    class Person {
        name: string;
        age: number;
    }

    class Student extends Person {
        private enrolled: Date;

        // Change parameter to union type
        setEnrolled(date: string | Date) {

            // See if a string was passed in
            if (typeof date === "string") {

                // Set enrolled to a new Date based on string
                this.enrolled = new Date(date);
            }
            else {
                this.enrolled = date;
            }
        }

        getEnrolled(): string {
            return this.enrolled.toDateString();
        }
    }

    let student = new Student();
    student.name = "Sue";
    student.age = 20;
    let today = new Date();
    // let dateString = `${today.getMonth()}/${today.getDate()}/${today.getFullYear()}`;
    // student.setEnrolled(dateString);
    student.setEnrolled(today);

    console.log(`Student named ${student.name}, age ${student.age}, ` +
        `enrolled on: ${student.getEnrolled()}`);
}