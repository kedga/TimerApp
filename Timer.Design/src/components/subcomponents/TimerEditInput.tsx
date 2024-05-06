import { ReactNode } from "react";

export default function TimerEditInput({
    success,
    children,
}: {
    success: boolean;
    children: ReactNode;
}) {
    return (
        <div className="w-full">
            <div className="w-full text-3xl flex justify-between items-baseline select-none font-bold text-start">
                <input
                    placeholder="Ramen"
                    className="w-full bg-edit-400 border-none outline-none rounded-xl px-4 placeholder:text-white"
                />
            </div>
            <div className="w-full py-4 flex justify-evenly gap-4 text-white text-3xl font-semibold">
                <div className="w-full flex gap-4 items-center">
                    <input
                        placeholder="3fdss"
                        className="w-full placeholder:opacity-30 shadow-inner h-fit bg-edit-400 border-none outline-none rounded-xl px-2 text-center placeholder:text-white"
                    />
                    <div
                        className={
                            "h-full aspect-square flex items-center rounded-full " +
                            (success ? "bg-green-500" : "bg-edit-400")
                        }>
                        {children}
                    </div>
                </div>
            </div>
        </div>
    );
}
