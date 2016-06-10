"#12-VSTDA-Backend" 

05/25 - Version 1.0. This is a barely functioning ToDo application that will enable you to achieve all of your greatest goals. Known issues - 

1. Need to refresh to get correct coloring on tasks, will re-order dynamically though. 

2. If task is added without a priority, it will still add to the list and server. Changed task coloring for said issue. 

3. When pressing cancel when "edit form" is showing, this will just hide the form, it will not revert any changes made to the task, or clear the input field. 

4. Error reporting is working kind of. Get correct Toastr response when passing "null", however, this only works when manually continuing the API run time. It will also pass "null" values if the browser is not refreshed. 

