# Project Charter: Emergency Check-In Application

## 1. Project Overview
The **Emergency Check-In Application** is a Blazor WebAssembly SPA designed to help employees quickly confirm their safety and location in the aftermath of an emergency. By integrating with Azure Active Directory (Azure AD), the application ensures that only authenticated employees can submit or view check-ins. The solution stores check-in data in Azure Table Storage and offers views for managers, peers, and administrators to track who has (or has not) reported in.

## 2. Purpose and Objectives
- **Employee Safety**: Provide a quick and reliable way for employees to check in as “OK” or request assistance if needed.
- **Real-Time Visibility**: Enable management and team leads to see staff status at a glance, including a map-based view of those who chose to share location.
- **Scalable and Secure**: Leverage Azure AD for authentication and Azure Functions + Table Storage for minimal operational overhead, high availability, and secure data handling.
- **Compliance and Privacy**: Respect employee privacy by making location sharing optional and limiting visibility to authorized users/roles.

## 3. Scope
### In-Scope
- **User Sign-In**: Single sign-on (SSO) with Azure AD credentials.
- **Check-In Workflow**: “Check-in now” button that captures an employee’s status (e.g., “OK” or “Need Assistance”), optional text note, and optional geolocation.
- **Storage**: Azure Table Storage for storing check-in records (timestamp, user info, status, location).
- **Views & Filters**:
  - **Peers**: Show immediate teammates’ statuses.
  - **Chain of Command**: View upward (managers) and downward (direct reports) check-ins.
  - **Department-Level**: Summarize statuses within a department (optional timeline chart).
  - **Map View**: Display geolocations of consenting employees on an interactive map.
  - **Missing Check-Ins**: Identify employees who have not checked in recently, factoring in Microsoft Graph user activity.
- **Deployment**: Visual Studio Code from a Mac, .NET 7/8 for cross-platform, with Azure Functions as backend APIs.

### Out-of-Scope
- **Complex Role-Based Access**: All employees can see check-in data, with optional filtering for managers. No elaborate permissions beyond basic sign-in.
- **Full Incident Management**: The system focuses solely on employee check-in; does not provide robust incident command features.

## 4. Deliverables
1. **Blazor WebAssembly SPA** with a user-friendly interface for check-ins and data visualization.
2. **Azure Functions** for API endpoints handling data insertions, retrievals, and Microsoft Graph calls (if needed for org info).
3. **Automated Deployments** to Azure (recommended: Azure Static Web Apps or similar pipeline).
4. **Documentation**:
   - Setup instructions (README).
   - Short user guide for employees/managers.
   - Security and privacy guidelines.

## 5. Stakeholders
- **Project Sponsor**: Oversees initiative, allocates budget/resources.
- **IT/Dev Team**: Designs, develops, tests, and maintains the application and Azure infrastructure.
- **HR/Facilities Teams**: Ensures adoption during emergencies, communicates usage to employees.
- **Employees**: Primary end-users checking in to confirm safety.
- **Managers/Leadership**: Monitors statuses to coordinate response efforts.

## 6. Project Milestones and Timeline
1. **Requirements Gathering** (1–2 weeks)  
2. **Initial Prototype** (2–3 weeks): Authentication, basic check-in form, data storage.  
3. **Extended Views** (3–4 weeks): Peers, department-wide, map integration.  
4. **Graph Integration** (2 weeks): Display chain of command, missing check-ins.  
5. **Testing & Hardening** (2–3 weeks): Security reviews, load testing, UX improvements.  
6. **Deployment**: Production rollout, documentation, and user training.

*(These durations are approximate; actual times may vary.)*

## 7. Success Criteria
- **User Adoption**: At least 80% of employees successfully check in within designated time frames during drills or real emergencies.
- **Performance**: Check-in form submissions and status pages load quickly (under 2 seconds in normal conditions).
- **Security**: Only authenticated employees can see check-ins; optional location sharing is enforced.
- **Scalability**: The application can handle peak usage during emergency events without significant downtime.

## 8. Risks and Dependencies
- **Risk**: Low adoption if employees are not properly trained.  
  **Mitigation**: Provide short “how-to” guides and practice drills.
- **Risk**: Data privacy concerns about sharing location.  
  **Mitigation**: Make location sharing optional and ensure data is only visible to relevant personnel.
- **Dependency**: Azure AD must be correctly set up for user authentication.
- **Dependency**: Project success depends on stable Azure services (Table Storage, Functions) and correct Graph permissions.

## 9. Budget and Resources
- **Azure Services**: Hosting costs for Functions, Storage, possible Map APIs (if using third-party).
- **Development Tools**: .NET, Visual Studio Code, GitHub.
- **Training**: Internal user training, system documentation, possible pilot test before final rollout.

## 10. Approval
By approving this charter, stakeholders agree on the objectives, scope, and approach of the Emergency Check-In Application.