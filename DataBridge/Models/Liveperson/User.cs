using System.Text.Json.Serialization;

namespace DataBridge.Models.Liveperson;

/// <summary>
/// Represents a user in the system, including both basic and detailed information.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets a value indicating whether the user is deleted.
    /// </summary>
    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }

    /// <summary>
    /// Gets or sets the login name of the user.
    /// </summary>
    [JsonPropertyName("loginName")]
    public string? LoginName { get; set; }

    /// <summary>
    /// Gets or sets the unique participant ID of the user.
    /// </summary>
    [JsonPropertyName("pid")]
    public string? Pid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or sets the detailed information of the user.
    /// </summary>
    [JsonPropertyName("userDetails")]
    public UserDetails? UserDetails { get; set; }
}

/// <summary>
/// Represents detailed information about a user in the system.
/// </summary>
public class UserDetails : User
{
    /// <summary>
    /// Gets or sets the user type identifier.
    /// </summary>
    [JsonPropertyName("userTypeId")]
    public int? UserTypeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to reset MFA secret.
    /// </summary>
    [JsonPropertyName("resetMfaSecret")]
    public bool? ResetMfaSecret { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is an API user.
    /// </summary>
    [JsonPropertyName("isApiUser")]
    public bool? IsApiUser { get; set; }

    /// <summary>
    /// Gets or sets the list of profile identifiers associated with the user.
    /// </summary>
    [JsonPropertyName("profileIds")]
    public List<long>? ProfileIds { get; set; }

    /// <summary>
    /// Gets or sets the list of permission groups associated with the user.
    /// </summary>
    [JsonPropertyName("permissionGroups")]
    public List<object>? PermissionGroups { get; set; }

    /// <summary>
    /// Gets or sets the allowed application keys for the user.
    /// </summary>
    [JsonPropertyName("allowedAppKeys")]
    public string? AllowedAppKeys { get; set; }

    /// <summary>
    /// Gets or sets the list of skills associated with the user.
    /// </summary>
    [JsonPropertyName("skills")]
    public List<Skill>? Skills { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user must change password on next login.
    /// </summary>
    [JsonPropertyName("changePwdNextLogin")]
    public bool? ChangePwdNextLogin { get; set; }

    /// <summary>
    /// Gets or sets the date when the user was created.
    /// </summary>
    [JsonPropertyName("dateCreated")]
    public string? DateCreated { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user was manually disabled.
    /// </summary>
    [JsonPropertyName("disabledManually")]
    public bool? DisabledManually { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of chats allowed for the user.
    /// </summary>
    [JsonPropertyName("maxChats")]
    public int? MaxChats { get; set; }

    /// <summary>
    /// Gets or sets the hashed password of the user.
    /// </summary>
    [JsonPropertyName("passwordSh")]
    public string? PasswordSh { get; set; }

    /// <summary>
    /// Gets or sets the list of skill identifiers associated with the user.
    /// </summary>
    [JsonPropertyName("skillIds")]
    public List<long>? SkillIds { get; set; }

    /// <summary>
    /// Gets or sets the nickname of the user.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// Gets or sets information about the user's membership in agent groups.
    /// </summary>
    [JsonPropertyName("memberOf")]
    public MemberOf? MemberOf { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user was created by LPA.
    /// </summary>
    [JsonPropertyName("lpaCreatedUser")]
    public bool? LpaCreatedUser { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the list of LOBs (Line of Business) associated with the user.
    /// </summary>
    [JsonPropertyName("lobs")]
    public List<object>? Lobs { get; set; }

    /// <summary>
    /// Gets or sets information about the agent groups managed by the user.
    /// </summary>
    [JsonPropertyName("managerOf")]
    public List<ManagerOf>? ManagerOf { get; set; }

    /// <summary>
    /// Gets or sets the list of profiles associated with the user.
    /// </summary>
    [JsonPropertyName("profiles")]
    public List<Profile>? Profiles { get; set; }

    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the employee identifier of the user.
    /// </summary>
    [JsonPropertyName("employeeId")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the list of agent groups managed by the user.
    /// </summary>
    [JsonPropertyName("managedAgentGroups")]
    public List<ManagedAgentGroup>? ManagedAgentGroups { get; set; }

    /// <summary>
    /// Gets or sets the date when the user was last updated.
    /// </summary>
    [JsonPropertyName("dateUpdated")]
    public string? DateUpdated { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is enabled.
    /// </summary>
    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    /// <summary>
    /// Gets or sets the date of the user's last password change.
    /// </summary>
    [JsonPropertyName("lastPwdChangeDate")]
    public string? LastPwdChangeDate { get; set; }
}

/// <summary>
/// Represents a skill associated with a user.
/// </summary>
public class Skill
{
    /// <summary>
    /// Gets or sets the name of the skill.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the skill.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }
}

/// <summary>
/// Represents information about a user's membership in an agent group.
/// </summary>
public class MemberOf
{
    /// <summary>
    /// Gets or sets the identifier of the agent group.
    /// </summary>
    [JsonPropertyName("agentGroupId")]
    public long? AgentGroupId { get; set; }

    /// <summary>
    /// Gets or sets the date when the user was assigned to the agent group.
    /// </summary>
    [JsonPropertyName("assignmentDate")]
    public string? AssignmentDate { get; set; }
}

/// <summary>
/// Represents information about an agent group managed by the user.
/// </summary>
public class ManagerOf
{
    /// <summary>
    /// Gets or sets the identifier of the agent group.
    /// </summary>
    [JsonPropertyName("agentGroupId")]
    public long? AgentGroupId { get; set; }

    /// <summary>
    /// Gets or sets the date when the user was assigned as a manager of the agent group.
    /// </summary>
    [JsonPropertyName("assignmentDate")]
    public string? AssignmentDate { get; set; }
}

/// <summary>
/// Represents a profile associated with a user.
/// </summary>
public class Profile
{
    /// <summary>
    /// Gets or sets the role type identifier of the profile.
    /// </summary>
    [JsonPropertyName("roleTypeId")]
    public int? RoleTypeId { get; set; }

    /// <summary>
    /// Gets or sets the name of the profile.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the profile.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }
}

/// <summary>
/// Represents an agent group managed by the user.
/// </summary>
public class ManagedAgentGroup
{
    /// <summary>
    /// Gets or sets the name of the managed agent group.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the managed agent group.
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }
}