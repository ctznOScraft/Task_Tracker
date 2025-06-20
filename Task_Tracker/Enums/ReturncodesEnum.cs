namespace Task_Tracker.Enums;

public enum ReturnCodes {
    OK = 0,
    ERR_INVALID_COMMAND = 1,
    ERR_NOT_ENOUGH_ARGS = 2,
    ERR_TASK_NOT_FOUND = 3,
    ERR_INVALID_TASK_ID = 4,
    ERR_INVALID_UPDATE_FIELD = 5,
    ERR_INVALID_STATUS_VALUE = 6,
    ERR_INVALID_LIST_OPTION = 7,
    ERR_UNSPECIFIED_FILENAME = 8,
    ERR_INVALID_CONFIG_OPTION = 9
}
