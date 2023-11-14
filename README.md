#Description

##Architecture
-The domain was already divided, but to ensure pattern consistency during expansion and maintenance by "various individuals", we chose to split layers into projects instead of folders.<br/>
-We designed it with minimal dependencies on the service.core project, which contains common elements, without achieving complete isolation each domains. In the concept of MSA architecture, complete isolation between domains is ideal, but it is not mandatory. This approach was introduced to facilitate integration with legacy systems due to the project's nature.