app.service("studentServices", function ($http) {


    // get all students
    this.getStudents = function () {

        return $http.get("Student/GetAllStudents");
    };

    // get student by id

    this.getStudent = function (studentId) {
        var response = $http({
            method: "post",
            url: "Student/GetStudentById",
            params: {
                id: JSON.stringify(studentId)
            }

        });

        return response;
    }

    // update student

    this.updateStudent = function (student) {
        var response = $http({
            method: "post",
            url: "Student/UpdateStudent",
            data: JSON.stringify(student),
            dataType: "json"
        });
        return response;
    }

    // Add Student

    this.AddStudent = function (student) {
        var response = $http({
            method: "post",
            url: "Student/AddStudent",
            data: JSON.stringify(student),
            dataType: "json"
        });

        return response;
    }

    // Delete Student

    this.DeleteStudent = function (id) {
        var response = $http({
            method: "post",
            url: "Student/DeleteStudent",
            params: {
                id: JSON.stringify(id)
            }
        });

        return response;
    }

   

});