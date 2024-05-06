import {
    faArrowLeftLong,
    faQuestion,
    faTrashCan,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import TimerEditInput from "./subcomponents/TimerEditInput";

type timerProps = {
    name: string;
    timeLimit: string;
    bgColor: string;
    askDelete?: boolean;
};

export default function Timer({}: timerProps) {
    return (
        <div className="bg-edit-500 timer-wrapper">
            <TimerEditInput success={false}>
                <i className="fa-solid fa-question mx-auto my-auto text-2xl"></i>
            </TimerEditInput>
            <div className="flex justify-between w-full">

                <button className="small-round-button hover:bg-edit-400">
                    <i className="fa-solid fa-arrow-left-long mx-auto my-auto text-2xl"></i>
                </button>

                <div className="w-full flex justify-end gap-4">
                    <button className="small-round-button hover:bg-edit-400">
                        <i className="fa-solid fa-trash-can mx-auto my-auto text-2xl"></i>
                    </button>
                </div>

            </div>
        </div>
    );
}
