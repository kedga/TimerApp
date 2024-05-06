import {
    faArrowLeftLong,
    faCheck,
    faFloppyDisk,
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
        <div className="bg-neutral-500 timer-wrapper">
            <TimerEditInput success={true}>
                <FontAwesomeIcon
                    className="mx-auto my-auto text-2xl translate-y-[1px] -translate-x-[1px]"
                    icon={faCheck}
                />
            </TimerEditInput>
            <div className="flex justify-between w-full items-center text-4xl font-semibold">
                <button className="small-round-button hover:bg-neutral-400">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-2xl"
                        icon={faArrowLeftLong}
                    />
                </button>

                <p className="w-full text-center opacity-30">120s</p>

                <div className="flex justify-end gap-4">
                    <button className="small-round-button hover:bg-neutral-400">
                        <FontAwesomeIcon
                            className="mx-auto my-auto text-2xl"
                            icon={faTrashCan}
                        />
                    </button>
                    {/* <button className="small-round-button hover:bg-neutral-400">
                        <FontAwesomeIcon
                            className="mx-auto my-auto text-2xl"
                            icon={faFloppyDisk}
                        />
                    </button> */}
                </div>
            </div>
        </div>
    );
}
