using Task_Tracker.Enums;

namespace Task_Tracker.Exceptions;

public class TaskTrackerException(string message, ReturnCodes errorCode) : Exception(message) {
    public ReturnCodes ErrorCode { get; } = errorCode;
}

public class NotEnoughArgumentsException(string command)
    : TaskTrackerException($"Not enough arguments for command '{command}'.", ReturnCodes.ERR_NOT_ENOUGH_ARGS);

public class InvalidTaskIdException()
    : TaskTrackerException("Invalid task ID provided.", ReturnCodes.ERR_INVALID_TASK_ID);

public class TaskNotFoundException(int taskId)
    : TaskTrackerException($"Task with ID {taskId} not found.", ReturnCodes.ERR_TASK_NOT_FOUND);

public class InvalidUpdateFieldException(string field) : TaskTrackerException(
    $"Invalid update field: {field}. Use 'description' or 'status'.", ReturnCodes.ERR_INVALID_UPDATE_FIELD);

public class InvalidStatusValueException(string status) : TaskTrackerException(
    $"Invalid status value: {status}. Use 'Todo', 'InProgress', or 'Done'.", ReturnCodes.ERR_INVALID_STATUS_VALUE);

public class InvalidListOptionException(string option) : TaskTrackerException(
    $"Invalid list option: {option}. Use 'Todo', 'InProgress', or 'Done'.'", ReturnCodes.ERR_INVALID_LIST_OPTION);

public class UnspecifiedFileNameException()
    : TaskTrackerException("Please specify file name for DB.", ReturnCodes.ERR_UNSPECIFIED_FILENAME);

public class InvalidConfigOptionException(string option) : TaskTrackerException(
    $"Invalid config option: {option}. Use 'dbname' (maybe more soon).", ReturnCodes.ERR_INVALID_CONFIG_OPTION);
